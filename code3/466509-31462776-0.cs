		private static void AttachToAllTraceSources(TraceListener yourListener)
		{
			TraceSource ts = new TraceSource("foo");
			List<WeakReference> list = (List<WeakReference>)GetInstanceField(typeof(TraceSource), ts, "tracesources");
			foreach(var weakReference in list)
			{
				if(weakReference.IsAlive)
				{
					TraceSource source = (weakReference.Target as TraceSource);
					if(source != null && source.Name != "foo")
					{
						source.Listeners.Add(yourListener);
					}
				}
			}
		}
