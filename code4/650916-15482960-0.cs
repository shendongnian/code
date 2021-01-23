		public void FindAndSetTemplateContent( ContentControl target, ViewModelBase item)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (item == null)
                throw new ArgumentNullException("item");
            var template = target.TryFindResource(new DataTemplateKey(item.GetType())) as DataTemplate; // this will pick up your resource for the viewmodel
            if (template == null)
                return null;
            var content = template.LoadContent() as ContentControl ;
            if (content != null)
            {
                content.DataContext = item;
            }
            return content;
        }
