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
	using System.Collections.ObjectModel;
	namespace StackOverflow
	{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
	private ObservableCollection<SampleClass> imgList = null;
	public MainWindow()
	{
	InitializeComponent();
	imgList = new ObservableCollection<SampleClass>();
	imgList.Add(new SampleClass() { ImgDesc = "First Image", ImgPath = @"/Images/MyImage.jpg" });
	this.DGImages.ItemsSource = imgList;
	this.DGImages.DataContext = imgList;
	}
	}
	}
