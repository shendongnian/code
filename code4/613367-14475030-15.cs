	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.ComponentModel;
	namespace StackOverflow
	{
	public class SampleClass : INotifyPropertyChanged
	{
	private string _ImgDesc;
	public string ImgDesc
	{
	get { return _ImgDesc; }
	set
	{
	_ImgDesc = value;
	OnPropertyChanged("ImgDesc");
	}
	}
	private string _ImgPath;
	public string ImgPath
	{
	get { return _ImgPath; }
	set
	{
	_ImgPath = value;
	OnPropertyChanged("ImgPath");
	}
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
