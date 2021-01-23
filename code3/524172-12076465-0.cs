        public bool IsAnyKeyDown()
        {
            var values = Enum.GetValues(typeof(Key));
            foreach (var v in values)
            {
                if (((Key)v) != Key.None)
                {
                    if (Keyboard.IsKeyDown((Key)v))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
