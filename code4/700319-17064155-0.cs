        public void AfterCreateChildElements(UIElement parent)
        {
            
        }
        public bool BeforeCreateChildElements(UIElement parent)
        {
            if (parent is PopupToolUIElement)
            {
                parent.Parent.ChildElements.Remove(parent);
            }
            return false;
        }
    }
