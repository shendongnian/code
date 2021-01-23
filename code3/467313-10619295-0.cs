    public class UiHtmlDocument : HtmlDocument {
        public UiHtmlDocument(UITestControl searchLimitContainer) : base(searchLimitContainer) {}
		
        public T searchHtmlElementByAttributeValue<T>(Dictionary<string,string> propertyExpressions) where T : UITestControl, new() {
            var uiTestControl = Activator.CreateInstance(typeof(T), this);
            foreach (var propertyExpression in propertyExpressions) {
                ((T)uiTestControl).SearchProperties[propertyExpression.Key] = propertyExpression.Value;
            }
            return (T)uiTestControl;
        }
    }
