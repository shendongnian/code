        protected void BindData(Client client)
        {
            string nameOfPropertyBeingReferenced; 
            nameOfPropertyBeingReferenced = MVP.Controller.GetPropertyName(() => client.Id);
            view.ClientId.BindTo(client, nameOfPropertyBeingReferenced);
            
            nameOfPropertyBeingReferenced = MVP.Controller.GetPropertyName(() => client.FullName);
            view.ClientName.BindTo(client, nameOfPropertyBeingReferenced);
        }
        public static void BindTo(this TextBox thisTextBox, object viewModelObject, string nameOfPropertyBeingReferenced)
        {
            Bind(viewModelObject, thisTextBox, nameOfPropertyBeingReferenced, "Text");
        }
        private static void Bind(object sourceObject, Control destinationControl, string sourceObjectMember, string destinationControlMember)
        {
            Binding binding = new Binding(destinationControlMember, sourceObject, sourceObjectMember, true, DataSourceUpdateMode.OnPropertyChanged);
            //Binding binding = new Binding(sourceObjectMember, sourceObject, destinationControlMember);
            destinationControl.DataBindings.Clear();
            destinationControl.DataBindings.Add(binding);
        }
        public static string GetPropertyName<T>(Expression<Func<T>> exp)
        {
            return (((MemberExpression)(exp.Body)).Member).Name;
        }
