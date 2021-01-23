		protected void ForAllSubviewUIControlsOfType<TUIType>(Action<TUIType, int> actionToPerform) where TUIType : UIView
		{
			processSubviewUIControlsOfType<TUIType>(this.View.Subviews, actionToPerform, 0);
		}
		
		private void processSubviewUIControlsOfType<TUIType>(UIView[] views, Action<TUIType, int> actionToPerform, int depth) where TUIType : UIView
		{
			if (views == null)
				return;
			if (actionToPerform == null)
				return;
			foreach (UIView view in views)
			{
				if (view.GetType () == typeof(TUIType))
				{
					actionToPerform((TUIType)view, depth);
				}
				if (view.Subviews != null)
				{
					foreach (UIView subview in view.Subviews)
					{
						processSubviewUIControlsOfType<TUIType>(view.Subviews, actionToPerform, depth + 1);	
					}
				}
			}
		}
