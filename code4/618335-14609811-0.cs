	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Data;
	using System.Windows.Documents;
	using System.Windows.Input;
	using System.Windows.Media;
	using System.Windows.Media.Imaging;
	using System.Windows.Navigation;
	using System.Windows.Shapes;
	using System.ComponentModel;
	using System.Collections.ObjectModel;
	namespace WpfApplication1
	{
		/// <summary>
		/// Interaction logic for MainWindow.xaml
		/// </summary>
		public partial class MainWindow : Window, INotifyPropertyChanged
		{
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
					Formulas =  new ObservableCollection<string>(CurrentMolecule.FormulasList.ToList());
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
			public MainWindow()
			{
				InitializeComponent();
				CurrentMolecule = new Molecule();
				DataContext = this;
			}
			public event PropertyChangedEventHandler PropertyChanged;
			public void OnPropertyChanged(string propertyName)
			{
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
				}
			}
		}
	}
