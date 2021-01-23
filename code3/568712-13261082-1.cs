    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Windows.Media;
    namespace EditableComboBox
    {
        class ComboBoxViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private string m_ComboBoxText;
            public string ComboBoxText
            {
                get { return m_ComboBoxText; }
                set
                {
                    m_ComboBoxText = value;
                    OnPropertyChanged("ComboBoxText");
                    ValidateText();
                }
            }
            private void ValidateText()
            {
                if (ComboBoxText.Length % 2 == 0)
                    ComboBoxColor = Brushes.Black;
                else
                    ComboBoxColor = Brushes.Red;
            }
            private Brush m_ComboBoxColor;
            public Brush ComboBoxColor
            {
                get { return m_ComboBoxColor; }
                set
                {
                    m_ComboBoxColor = value;
                    OnPropertyChanged("ComboBoxColor");
                }
            }
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
