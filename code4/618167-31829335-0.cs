        SomeObject.MethodInTargetProject(Type.GetType(FullTypeName));
    
        public void MethodInTargetProject(Type formType)
        {
            if (newFormType == null)
                return;
            var obj = Activator.CreateInstance(newFormType);
            ...
        }
