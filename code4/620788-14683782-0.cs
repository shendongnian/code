        public static void MaskInt(this TextBox tb)
        {
            tb.PreviewTextInput += (s, e) =>
            {
                int val;
                e.Handled = !int.TryParse(e.Text, out val);
            };
        }
