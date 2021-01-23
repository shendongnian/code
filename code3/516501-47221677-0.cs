    using System;
    using System.Drawing;
    using System.Windows.Forms;
    public class PlaceHolderTextBox : TextBox
    {
        private bool isPlaceHolder = true;
        private string placeHolderText;
        public string PlaceHolderText
        {
            get { return placeHolderText; }
            set
            {
                placeHolderText = value;
                SetPlaceholder();
            }
        }
        public PlaceHolderTextBox()
        {
            TextChanged += OnTextChanged;
        }
        private void SetPlaceholder()
        {
            if (!isPlaceHolder)
            {
                this.Text = placeHolderText;
                this.ForeColor = Color.Gray;
                isPlaceHolder = true;
            }
        }
        private void RemovePlaceHolder()
        {
            if (isPlaceHolder)
            {
                this.Text = this.Text[0].ToString(); // Remove placeHolder text, but keep the character we just entered
                this.Select(1, 0); // Place the caret after the character we just entered
                this.ForeColor = System.Drawing.SystemColors.WindowText;
                isPlaceHolder = false;
            }
        }
        private void OnTextChanged(object sender, EventArgs e)
        {
            if (this.Text.Length == 0)
            {
                SetPlaceholder();
            }
            else
            {
                RemovePlaceHolder();
            }
        }
    }
