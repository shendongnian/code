        public void ProcessGlobal()
        {
            var globalType = _global.GetType(); // globalType = Expression<Func<TClass, TProperty>>
            var functionType = globalType.GetGenericArguments()[0]; // functionType = Func<TClass, TProperty>
            var functionGenericArguments = functionType.GetGenericArguments(); // v = [TClass, TProperty]
            var method = this.GetType().GetMethod("AssignToGlobal").MakeGenericMethod(functionGenericArguments); //functionGenericArguments = AssignToGlobal<TClass, TProperty>
            method.Invoke(this, new[] { this._global }); // Call AssignToGlobal<TClass, TProperty>)(this._global);
        }
