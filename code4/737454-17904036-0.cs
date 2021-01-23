	    public static readonly DependencyProperty Text1Property =
		    DependencyProperty.Register("Text1", typeof(decimal), typeof(Form), 
                                        new PropertyMetadata(default(decimal)));
	    public decimal Text1
	    {
			get { return (decimal)GetValue(Text1Property); }
		    set
		    {
			    SetValue(Text1Property, value);
			    SetValue(Text2Property, TotalValue - value);
		    }
	    }
