		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.TabLayoutTutorial);
			TabHost.TabSpec spec;     // Resusable TabSpec for each tab  
			Intent intent;            // Reusable Intent for each tab  
			// Create an Intent to launch an Activity for the tab (to be reused)  
			intent = new Intent (this, typeof (ArtistsActivity));
			intent.AddFlags (ActivityFlags.NewTask);
			// Initialize a TabSpec for each tab and add it to the TabHost  
			spec = TabHost.NewTabSpec ("artists");
			spec.SetIndicator ("Artists", Resources.GetDrawable (Resource.Drawable.ic_tab_artists));
			spec.SetContent (intent);
			TabHost.AddTab (spec);
			// Do the same for the other tabs  
			intent = new Intent (this, typeof (AlbumsActivity));
			intent.AddFlags (ActivityFlags.NewTask);
			spec = TabHost.NewTabSpec ("albums");
			spec.SetIndicator ("Albums", Resources.GetDrawable (Resource.Drawable.ic_tab_artists));
			spec.SetContent (intent);
			TabHost.AddTab (spec);
			intent = new Intent (this, typeof (SongsActivity));
			intent.AddFlags (ActivityFlags.NewTask);
			spec = TabHost.NewTabSpec ("songs");
			spec.SetIndicator ("Songs", Resources.GetDrawable (Resource.Drawable.ic_tab_artists));
			spec.SetContent (intent);
			TabHost.AddTab (spec);
			TabHost.CurrentTab = 2;
		}
