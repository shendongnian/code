    using GalaSoft.MvvmLight;
    
    namespace Test_DataGridSelectedIndexItem
    {
        public class ItemViewModel : ViewModelBase
        {
            private string text;
            
            public ItemViewModel() : this(string.Empty)
            {
            }
    
            public ItemViewModel(string text)
            {
                this.text = text;
            }
    
            public string Text
            {
                get
                {
                    return this.text;
                }
                set
                {
                    this.text = value;
                    this.RaisePropertyChanged(() => this.Text);
                }
            }
    
            public override string ToString()
            {
                return this.text;
            }
        }
    }
