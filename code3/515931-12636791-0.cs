			this.Loaded += delegate
			{
				var source = PresentationSource.FromVisual(this);
				var hwndTarget = source.CompositionTarget as HwndTarget;
				if (hwndTarget != null)
				{
					hwndTarget.RenderMode = RenderMode.SoftwareOnly;
				}
			};
