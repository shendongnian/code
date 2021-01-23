	public partial class Photographer : NSManagedObject
	{
		public static NSString NameKey = (NSString) "name";
		public static NSString PhotosKey = (NSString) "photos";
		public Photographer(IntPtr handle) : base(handle)
		{
		}
		public string Name
		{
			get { return (NSString) Runtime.GetNSObject(ValueForKey(NameKey)); }
			set { SetValueForKey(value, NameKey); }
		}
		public NSSet Photos
		{
			get { return (NSSet) Runtime.GetNSObject(ValueForKey(PhotosKey)); }
			set { SetValueForKey(value, PhotosKey); }
		}
		void SetValueForKey(string value, NSString key)
		{
			base.SetValueForKey((NSString)(value ?? ""), key);
		}
		public static Photographer InsertNewObject(NSManagedObjectContext context)
		{
			return (Photographer) NSEntityDescription.InsertNewObjectForEntityForName("Photographer", context);
		}
		public static Photographer WithName(string name, NSManagedObjectContext context)
		{
			Photographer photographer = null;
			// This is just like Photo(Flickr)'s method.  Look there for commentary.
			if (name.Length > 0)
			{
				var request = new NSFetchRequest("Photographer")
				{
					SortDescriptors = new[] {new NSSortDescriptor("name", true, new Selector("localizedCaseInsensitiveCompare:"))},
					Predicate =  NSPredicate.FromFormat("name = %@", new NSObject[] {(NSString) name})
				};
				NSError error;
				var matches = context.ExecuteFetchRequest(request, out error);
				if (matches == null || matches.Length > 1)
				{
					// handle error
				}
				else if (matches.Length == 0)
				{
					photographer = InsertNewObject(context);
					photographer.Name = name;
				}
				else
				{
					photographer = (Photographer) matches.First();
				}
			}
			return photographer;
		}
	}
	public partial class Photo : NSManagedObject
	{
        public static NSString ImageUrlKey = (NSString) "imageURL";
        public static NSString TitleKey = (NSString) "title";
        public static NSString UniqueKey = (NSString) "unique";
        public static NSString SubtitleKey = (NSString) "subtitle";
        public static NSString WhoTookKey = (NSString) "whoTook";
		public Photo (IntPtr handle) : base (handle)
		{
		}
        public string ImageUrl  {
            get { return (NSString)Runtime.GetNSObject(ValueForKey(ImageUrlKey)); }
            set { SetValueForKey(value, ImageUrlKey); }
        }
        public string Subtitle  {
            get { return (NSString)Runtime.GetNSObject(ValueForKey(SubtitleKey)); }
			set { SetValueForKey(value, SubtitleKey); }
        }
        public string Title  {
            get { return (NSString)Runtime.GetNSObject(ValueForKey(TitleKey)); }
			set { SetValueForKey(value, TitleKey); }
        }
        public string Unique  {
            get { return (NSString)Runtime.GetNSObject(ValueForKey(UniqueKey)); }
			set { SetValueForKey(value, UniqueKey); }
        }
        public Photographer WhoTook  {
			get { return (Photographer)Runtime.GetNSObject(ValueForKey(WhoTookKey)); }
            set { SetValueForKey(value, WhoTookKey); }
        }
	void SetValueForKey(string value, NSString key)
	{
		base.SetValueForKey((NSString) (value??""), key);
	}
        public static Photo InsertNewObject(NSManagedObjectContext context)
        {
            return (Photo) NSEntityDescription.InsertNewObjectForEntityForName("Photo", context);
        }
        public UIImage Image
        {
            get {
                if (string.IsNullOrEmpty(ImageUrl))
                    return null;
                var imageData = NSData.FromUrl(new NSUrl(ImageUrl));
                if (imageData == null)
                    return null;
                return new UIImage(imageData);
            }
        }
