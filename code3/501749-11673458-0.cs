    internal virtual void GenerateChildren()
    {
    	IItemContainerGenerator itemContainerGenerator = this._itemContainerGenerator;
    	if (itemContainerGenerator != null)
    	{
    		using (itemContainerGenerator.StartAt(new GeneratorPosition(-1, 0), GeneratorDirection.Forward))
    		{
    			UIElement uIElement;
    			while ((uIElement = (itemContainerGenerator.GenerateNext() as UIElement)) != null)
    			{
    				this._uiElementCollection.AddInternal(uIElement);
    				itemContainerGenerator.PrepareItemContainer(uIElement);
    			}
    		}
    	}
    }
