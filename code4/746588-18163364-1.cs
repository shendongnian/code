    [Activity (Label = "Documents")]			
	public class DocumentsActivity : ListActivity
	{
		string path;
		ListView ourlist;
		TextView folder;
		ImageButton back;
		ImageButton home;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.DocumentsActivity);
			back = FindViewById<ImageButton> (Resource.Id.imageButton1);
			back.Click += delegate {
				this.BackClick();
			};
			back.LongClick += delegate {
				UserHelper.BackButton(this);
			};
			ourlist = FindViewById<ListView> (Android.Resource.Id.List);
			folder = FindViewById<TextView> (Resource.Id.folder);
			path = Android.OS.Environment.ExternalStorageDirectory.ToString();
			folder.Text = "Folder: "+new DirectoryInfo (path).Name;
			ourlist.Adapter = new FileAdapter (path, this);
		}
		private void CreateFolder(string path)
		{
			if (!Directory.Exists (path))
				Directory.CreateDirectory (path);
		}
		private void BackClick()
		{
			DirectoryInfo dir = new DirectoryInfo(path);
			ourlist.Adapter = new FileAdapter (dir.Parent.FullName, this);
			folder.Text = "Folder: "+dir.Parent.Name;
		} 
		protected override void OnListItemClick(ListView l, View v, int position, long id)
		{
			FileAdapter files = (FileAdapter)l.Adapter; 
			var t = files.Items[position];
			if (t is DirectoryInfo) {
			//Folder Behavior : 
				path = t.FullName;
				folder.Text = "Folder: "+t.Name;
				ourlist.Adapter = new FileAdapter (t.FullName,this);
			} else 
			{
			// File Behavior: (This is where will work will come in!)
				Android.Widget.Toast.MakeText (this, t.Name, Android.Widget.ToastLength.Short).Show ();
			}
		}
	}
    
    public class FileAdapter : BaseAdapter <FileSystemInfo>
	{
		Activity _activity;
		string path;
		DirectoryInfo dir;
		public FileAdapter (string path,Activity act)
		{
			Items = new List<FileSystemInfo> ();
			dir = new DirectoryInfo (path);
			Items.AddRange (dir.GetDirectories().Where(z => !z.Name.StartsWith(".")).Cast<FileSystemInfo>().ToList());
			Items.AddRange (dir.GetFiles ());
			_activity = act;
		}
		public override FileSystemInfo this [int position] { 
			get { return Items[position]; }
		}
		public override int Count {
			get { return Items.Count() ; }
		}
		public override long GetItemId (int position)
		{
			return Items[position].GetHashCode();
		}
		public List<FileSystemInfo> Items {
			get;
			set;
		}
		public override View GetView (int position, View convertView, ViewGroup parent)
		{           
			View view = convertView; 
		
			if (view == null)
				view = _activity.LayoutInflater.Inflate (Resource.Layout.CustomView, null);
			if (Items [position] is DirectoryInfo) {
				ImageView imageview = view.FindViewById<ImageView> (Resource.Id.Image);
				imageview.SetImageResource (Resource.Drawable.Folder);
			} else {
				ImageView imageview = view.FindViewById<ImageView> (Resource.Id.Image);
				imageview.SetImageResource (Resource.Drawable.Files);
			}
			TextView text = view.FindViewById<TextView> (Resource.Id.Text1);
			text.Text = Items[position].Name;
			text.SetMinimumHeight (50);
			text.SetTextSize (Android.Util.ComplexUnitType.Pt, 10);
			return view;
		}
	}
