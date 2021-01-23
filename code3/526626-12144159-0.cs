        [ProtoAfterDeserialization]
        protected void OnDeserialized()
        {
            if (ControlesInternes.Count > 0)
            {
                foreach (var ctl in ControlesInternes)
                {
                    ctl.Parent = this;
                }
            }
        }
