        public static void UnloadTabpage(TabPage page) {
            for (int ix = page.Controls.Count - 1; ix >= 0; --ix) {
                page.Controls[ix].Dispose();
            }
        }
