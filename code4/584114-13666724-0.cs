			object obj = Volatile.Read<object>(ref this.m_threadSafeObj);
			bool flag = false;
			try
			{
				if (obj != Lazy<T>.ALREADY_INVOKED_SENTINEL)
				{
					Monitor.Enter(obj, ref flag);
				}
				if (this.m_boxed == null)
				{
					boxed = this.CreateValue();
					this.m_boxed = boxed;
					Volatile.Write<object>(ref this.m_threadSafeObj, Lazy<T>.ALREADY_INVOKED_SENTINEL);
				}
				else
				{
					boxed = (this.m_boxed as Lazy<T>.Boxed);
					if (boxed == null)
					{
						Lazy<T>.LazyInternalExceptionHolder lazyInternalExceptionHolder = this.m_boxed as Lazy<T>.LazyInternalExceptionHolder;
						lazyInternalExceptionHolder.m_edi.Throw();
					}
				}
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(obj);
				}
			}
