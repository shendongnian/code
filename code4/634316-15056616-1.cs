        public void collisionChecks()
        {            
            List<UIElement> AllCollidables = Collidables.Children.ToList();
            collisionEnabled.Clear();
            foreach (UIElement item in AllCollidables)
            {
                if (Canvas.GetTop((Image)item) + canvasShift > 0)
                    collisionEnabled.Add(item as Image);
            }
        }
