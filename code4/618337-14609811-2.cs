	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.ComponentModel;
	using System.Collections.ObjectModel;
	namespace WpfApplication1
	{
		public class ViewModel : INotifyPropertyChanged
		{
			#region Properties
			private Molecule _CurrentMolecule;
			public Molecule CurrentMolecule
			{
				get
				{
					return _CurrentMolecule;
				}
				set
				{
					_CurrentMolecule = value;
					OnPropertyChanged("CurrentMolecule");
					Formulas = new ObservableCollection<string>(CurrentMolecule.FormulasList.ToList());
				}
			}
			private ObservableCollection<string> _Formulas;
			public ObservableCollection<string> Formulas
			{
				get { return _Formulas; }
				set
				{
					_Formulas = value;
					OnPropertyChanged("Formulas");
				}
			}
			#endregion
			#region Constructor
			public ViewModel()
			{
				CurrentMolecule = new Molecule();
			}
			#endregion
			#region INotifyPropertyChanged implementation
			public event PropertyChangedEventHandler PropertyChanged;
			public void OnPropertyChanged(string propertyName)
			{
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
				}
			}
			#endregion
		}
	}
