    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using WindowsFormsApplication2.Annotations;
    namespace WindowsFormsApplication2
    {
    public class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        #region Notyfier implementation
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region collection implemetation
        public BindingList<Item> Items = new BindingList<Item>();
        public string Count
        {
            get { return (Items.Count == 1) 
                ? "1 item." 
                : Items.Count + " items."; }
        }
        public Item Current
        {
            get { return Items.Count == 0 
                ? new Item {Colour = Color.Chartreuse} //default initial item
                : Items.Last(); }
        }
        #endregion
        #region object implemetation
        
        protected object ID { get; set; }
        public Color Colour { get; set; }
        
        public void NewItem(Color color)
        {
            Items.Add(new Item
                {
                    ID = Guid.NewGuid(), 
                    Colour = color
                });
            
            OnPropertyChanged("Count");
            OnPropertyChanged("Current");
        }
        
        #endregion
    }
    }
