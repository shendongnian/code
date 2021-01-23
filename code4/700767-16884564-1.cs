	[BaseType (typeof (NSObject))]
	interface NIViewRecycler {
		[Export ("dequeueReusableViewWithIdentifier:")]
		NIRecyclableView DequeueReusableView (string reuseIdentifier);
		[Export ("recycleView:")]
		void RecycleView (NIRecyclableView view);
		[Export ("removeAllViews")]
		void RemoveAllViews ();
	}
	[BaseType (typeof (NSObject), Name = "NIRecyclableView")]
	interface NIRecyclableViewProtocol {
		[Export ("reuseIdentifier", ArgumentSemantic.Copy)]
		string ReuseIdentifier { get; set; }
		[Export ("prepareForReuse")]
		void PrepareForReuse ();
	}
	
	// Here you would do interface NIRecyclableView : NIRecyclableViewProtocol
	// But NIRecyclableView already implements reuseIdentifier
	// So you just inline the missing method PrepareForReuse
	// and you get the same results
	[BaseType (typeof (UIView))]
	interface NIRecyclableView {
		[Export ("initWithReuseIdentifier:")]
		IntPtr Contructor (string reuseIdentifier);
		[Export ("reuseIdentifier", ArgumentSemantic.Copy)]
		string ReuseIdentifier { get; set; }
		[Export ("prepareForReuse")]
		void PrepareForReuse ();
	}
