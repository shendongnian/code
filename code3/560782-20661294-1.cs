        public static class AppExtensions
        {
            public static void UncheckAllItems(this System.Windows.Forms.CheckedListBox clb)
            {
                while (clb.CheckedIndices.Count > 0)
                    clb.SetItemChecked(clb.CheckedIndices[0], false);
            }
        }
