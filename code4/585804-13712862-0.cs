        void building()
        {
            var items = getItemsFromXml();
            foreach (var item in items)
            {
                var control = BuildControl(item);
                this.EventToHandle += control.PublicEventHandlerMethod();
                this.Controls.Add(control);
            }
        }
