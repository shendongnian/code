        public bool ApplyVisualBlock(FrameworkElement visulaBlock)
        {
            //update binding values
            UpdateAllBindingTargets(visulaBlock);
            _contentContainer.Children.Add(visulaBlock);
            //calculate size
            visulaBlock.Measure(new Size(ContentWidth, ContentHeight));
            double visualBlockHeight = Math.Ceiling(visulaBlock.DesiredSize.Height);
            if ((visualBlockHeight + _currentContentHeight) > ContentHeight)
            {
                //if current cocntent height more than page height go to other page 
                _contentContainer.Children.Remove(visulaBlock);
                return false;
            }
            _currentContentHeight = _currentContentHeight + visualBlockHeight;
            return true;
            
        }
 
     public  void UpdateAllBindingTargets( DependencyObject obj)
        {
                FrameworkElement visualBlock = obj as FrameworkElement;
            if (visualBlock==null)
                return;
            if (visualBlock.DataContext==null)
                return;
            Object objDataContext = visualBlock.DataContext;
            IEnumerable<KeyValuePair<DependencyProperty, BindingExpression>> allElementBinding = GetAllBindings(obj);
            foreach (KeyValuePair<DependencyProperty, BindingExpression> bindingInfo in allElementBinding)
            {
                BindingOperations.ClearBinding(obj, bindingInfo.Key);
             
                Binding myBinding = new Binding(bindingInfo.Value.ParentBinding.Path.Path);
                myBinding.Source = objDataContext;
                visualBlock.SetBinding(bindingInfo.Key, myBinding);
                BindingOperations.GetBindingExpression(visualBlock, bindingInfo.Key).UpdateTarget();
            }
        }
        public  IEnumerable<KeyValuePair<DependencyProperty, BindingExpression>> GetAllBindings( DependencyObject obj)
        {
            var stack = new Stack<DependencyObject>();
            stack.Push(obj);
            while (stack.Count > 0)
            {
                var cur = stack.Pop();
                var lve = cur.GetLocalValueEnumerator();
                while (lve.MoveNext())
                    if (BindingOperations.IsDataBound(cur, lve.Current.Property))
                    {
                        KeyValuePair<DependencyProperty,BindingExpression> result=new KeyValuePair<DependencyProperty, BindingExpression>(lve.Current.Property,lve.Current.Value as BindingExpression);
                        yield return result;
                    }
                int count = VisualTreeHelper.GetChildrenCount(cur);
                for (int i = 0; i < count; ++i)
                {
                    var child = VisualTreeHelper.GetChild(cur, i);
                    if (child is FrameworkElement)
                        stack.Push(child);
                }
            }
        }
