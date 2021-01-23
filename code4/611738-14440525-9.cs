        private string LoadMailTemplate()
        {
            var sb = new StringBuilder();
            using (var sw = new StringWriter(sb))
            {
                this.Server.Execute(this, sw, false);
            }
            return sb.ToString();
        }
