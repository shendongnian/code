    this.tb.AddHandler(UIElement.DragOverEvent, new DragEventHandler((sender, e) =>
        {
            e.Effects = !e.Data.GetDataPresent("treeThing") ? 
                DragDropEffects.None : 
                DragDropEffects.Copy;                    
        }), true);
    
    this.tb.AddHandler(UIElement.DropEvent, new DragEventHandler((sender, e) =>
    {
        if (e.Data.GetDataPresent("treeThing"))
        {
            var item = e.Data.GetData("treeThing") as TreeThing;
            if (item != null)
            {
                tb.Text = item.Path;
                // TODO: Actually open up the file here
            }
        }
    }), true);
