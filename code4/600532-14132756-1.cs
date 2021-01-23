		void RaisePropertyChanged<T>(Expression<Func<T>> selectorExpression)
		{
			var handler = PropertyChanged;
			if (handler != null)
			{
				MemberExpression body = selectorExpression.Body as MemberExpression;
			
				handler(this, new PropertyChangedEventArgs(body.Member.Name));
			}
		}
		
        public string Name
		{
			set
			{
				_name = value;
				RaisePropertyChanged( () => this.Name); // Property is specified instead of name that removes typing error
			}
		}
