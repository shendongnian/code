        private void button1_Click(object sender, EventArgs e) {
            var menus = new string[] { "Every", "menu", "you", "want", "to", "show" };
            foreach (var mnu in this.GetType().GetFields(
                BindingFlags.Instance | 
                BindingFlags.NonPublic | 
                BindingFlags.GetField)) {
                var member = mnu.GetValue(this) as MenuStrip;
                if (null != member) {
                    member.Visible = (menus.Contains(member.Tag.ToString()));
                }
            }
        }
