        public HtmlString Toolbar(DynamicEntity target = null, string dontRelyOnParameterOrder = Constants.RandomProtectionParameter, string actions = null, string contentType = null, object prefill = null)
        {
            if (!Enabled) return null;
            protectAgainstMissingParameterNames(dontRelyOnParameterOrder);
            var toolbar = new ItemToolbar(target, actions, contentType, prefill);
            return new HtmlString(toolbar.Toolbar);
        }
        private void protectAgainstMissingParameterNames(string criticalParameter)
        {
            if(criticalParameter != Constants.RandomProtectionParameter)
                throw new Exception("when using the toolbar command, please use named parameters - otherwise you are relying on the parameter order staying the same.");
            
        }
