    public class CollectionPropertyBehavior : Behavior<DependencyObject>
    {
        private IEnumerable<ValueProxy> proxies;
        private bool syncking;
        public string SourcePropertyPath
        {
            get { return (string)GetValue(SourcePropertyPathProperty); }
            set { SetValue(SourcePropertyPathProperty, value); }
        }
        public static readonly DependencyProperty SourcePropertyPathProperty =
            DependencyProperty.Register("SourcePropertyPath", typeof(string), typeof(CollectionPropertyBehavior), new PropertyMetadata(null));
        public string CollectionPropertyPath
        {
            get { return (string)GetValue(CollectionPropertyPathProperty); }
            set { SetValue(CollectionPropertyPathProperty, value); }
        }
        public static readonly DependencyProperty CollectionPropertyPathProperty =
            DependencyProperty.Register("CollectionPropertyPath", typeof(string), typeof(CollectionPropertyBehavior), new PropertyMetadata(null));
        private IEnumerable<object> Items { get { return  this.ItemsSource == null ? null : this.ItemsSource.OfType<object>(); } }
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(CollectionPropertyBehavior), new PropertyMetadata(null, ItemsSourceChanged));
        private object Value
        {
            get { return (object)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        private static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(object), typeof(CollectionPropertyBehavior), new PropertyMetadata(null, ValueChanged));
        public object DefaultValue
        {
            get { return (object)GetValue(DefaultValueProperty); }
            set { SetValue(DefaultValueProperty, value); }
        }
        public static readonly DependencyProperty DefaultValueProperty =
            DependencyProperty.Register("DefaultValue", typeof(object), typeof(CollectionPropertyBehavior), new PropertyMetadata(null));
        private static void ValueChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            var element = sender as CollectionPropertyBehavior;
            if (element == null || element.ItemsSource == null) return;
            element.UpdateCollection();
        }
        private static void ItemsSourceChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            var element = sender as CollectionPropertyBehavior;
            if (element == null || element.ItemsSource == null) return;
            element.ItemsSourceChanged();
        }
        private void ItemsSourceChanged()
        {
            this.proxies = null;
            if (this.Items == null || !this.Items.Any() || this.CollectionPropertyPath == null) return;
            // Cria os proxies
            this.proxies = this.Items.Select(o =>
            {
                var proxy = new ValueProxy();
                proxy.Bind(o, this.CollectionPropertyPath);
                proxy.ValueChanged += (s, e) => this.UpdateSource();
                return proxy;
            }).ToArray();
            this.UpdateSource();
        }
        private void UpdateSource()
        {
            if (this.syncking) return;
            // Atualiza o valor 
            using (new SynckingScope(this))
            {
                object value = this.proxies.First().Value;
                foreach (var proxy in this.proxies.Skip(1))
                {
                    value = object.Equals(proxy.Value, value) ? value : this.DefaultValue;
                }
                this.Value = value;
            }
        }
        private void UpdateCollection()
        {
            // Se o valor estiver mudando em função da atualização de algum 
            // elemento da coleção, não faz nada
            if (this.syncking) return;
            using (new SynckingScope(this))
            {
                // Atualiza todos os elementos da coleção,
                // atrávés dos proxies
                if (this.proxies != null)
                    foreach (var proxy in this.proxies)
                        proxy.Value = this.Value;
            }
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            // Bind da propriedade do objeto fonte para o behavior
            var binding = new Binding(this.SourcePropertyPath);
            binding.Source = this.AssociatedObject;
            binding.Mode = BindingMode.TwoWay;
            BindingOperations.SetBinding(this, ValueProperty, binding);
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            // Limpa o binding de value para a propriedade do objeto associado
            this.ClearValue(ValueProperty);
        }
        internal class SynckingScope : IDisposable
        {
            private readonly CollectionPropertyBehavior parent;
            public SynckingScope(CollectionPropertyBehavior parent)
            {
                this.parent = parent;
                this.parent.syncking = true;
            }
            public void Dispose()
            {
                this.parent.syncking = false;
            }
        }
        internal class ValueProxy : DependencyObject
        {
            public event EventHandler ValueChanged;
            public object Value
            {
                get { return (object)GetValue(ValueProperty); }
                set { SetValue(ValueProperty, value); }
            }
            public static readonly DependencyProperty ValueProperty =
                DependencyProperty.Register("Value", typeof(object), typeof(ValueProxy), new PropertyMetadata(null, OnValueChanged));
            private static void OnValueChanged(object sender, DependencyPropertyChangedEventArgs args)
            {
                var element = sender as ValueProxy;
                if (element == null || element.ValueChanged == null) return;
                element.ValueChanged(element, EventArgs.Empty);
            }
            public void Bind(object source, string path)
            {
                // Realiza o binding de value com o objeto desejado
                var binding = new Binding(path);
                binding.Source = source;
                binding.Mode = BindingMode.TwoWay;
                BindingOperations.SetBinding(this, ValueProperty, binding);
            }
        }
    }
