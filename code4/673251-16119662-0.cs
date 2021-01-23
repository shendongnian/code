    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Checks
    {
    	class ChecksModel : INotifyPropertyChanged
    	{
    		public ChecksModel(string label, bool status)
    		{
    			Children = new ObservableCollection<ChecksModel>();
    			Label = label;
    			IsChecked = status;
    		}
    		public ChecksModel(string label)
    			: this(label, false)
    		{
    		}
    
    		public ChecksModel()
    		{
    			Children = new ObservableCollection<ChecksModel>();
    		}
    		public void AddChild(ChecksModel child)
    		{
    			Children.Add(child);
    		}
    
    
    		public event PropertyChangedEventHandler PropertyChanged;
    		protected void OnPropertyChanged(string name)
    		{
    			PropertyChangedEventHandler handler = PropertyChanged;
    			if (handler != null)
    			{
    				handler(this, new PropertyChangedEventArgs(name));
    			}
    		}
    
    		private ObservableCollection<ChecksModel> _Children;
    		public ObservableCollection<ChecksModel> Children
    		{
    			get
    			{
    				return _Children;
    			}
    			set
    			{
    				_Children = value;
    				OnPropertyChanged("Children");
    			}
    		}
    		private string _Label;
    		public string Label
    		{
    			get
    			{
    				return _Label;
    			}
    			set
    			{
    				_Label = value;
    				OnPropertyChanged("Label");
    			}
    			
    		}
    		private bool _IsChecked;
    		public bool IsChecked
    		{
    			get
    			{
    				return _IsChecked;
    			}
    			set
    			{
    				_IsChecked = value;
    				OnPropertyChanged("IsChecked");
    				CheckNodes(value);
    			}
    		}
    		private void CheckNodes(bool value)
    		{
    			foreach (ChecksModel m in _Children)
    			{
    				m.IsChecked = value;
    			}
    		}
    	}
    }
