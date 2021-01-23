		partial class TestClass {
			public static void TestMethod() {
				Service<ServiceProxy1>.Use(svc => svc.Method());
				Service<ServiceProxy1>.Use(svc => svc.Method());
				Service<ServiceProxy1>.Use(svc => svc.Method());
				Service<ServiceProxy2>.Use(svc => svc.Method());
			}
		}
		public partial interface IServiceProxyFactory<T> {
			T GetServiceProxy();
		}
		public partial class Service<T> where T: ServiceProxy, new() {
			public static void Use(Action<T> codeBlock) {
				using(var client=ServiceProxy.GetServiceProxy<T>().GetServiceProxy() as T)
					try {
						codeBlock(client);
					}
					catch {
						throw;
					}
			}
		}
		public abstract partial class ServiceProxy: CommunicationObject, IDisposable {
			public static T GetServiceProxy<T>() where T: ServiceProxy, new() {
				var proxy=m_List.FirstOrDefault(x => typeof(T).Equals(x.GetType())) as T;
				if(null==proxy) {
					proxy=new T();
					m_List.Add(proxy);
				}
				return proxy;
			}
			public abstract ServiceProxy GetServiceProxy();
			public abstract void Method();
			protected virtual void Dispose(bool disposing) {
				lock(ThisLock)
					if(!this.IsDisposed&&disposing) {
						this.Close();
						if(!this.IsDisposed)
							this.Abort();
					}
			}
			public void Dispose() {
				this.Dispose(true);
				GC.SuppressFinalize(this);
			}
			~ServiceProxy() {
				this.Dispose(false);
			}
			static List<ServiceProxy> m_List=new List<ServiceProxy>();
		}
		public partial class ServiceProxy1: ServiceProxy {
			protected override IAsyncResult OnBeginClose(
				TimeSpan timeout, AsyncCallback callback, object state
				) {
				throw new NotImplementedException();
			}
			protected override IAsyncResult OnBeginOpen(
				TimeSpan timeout, AsyncCallback callback, object state
				) {
				throw new NotImplementedException();
			}
			protected override void OnAbort() {
			}
			protected override void OnEndClose(IAsyncResult result) {
			}
			protected override void OnEndOpen(IAsyncResult result) {
			}
			protected override void OnClose(TimeSpan timeout) {
			}
			protected override void OnOpen(TimeSpan timeout) {
			}
			protected override TimeSpan DefaultCloseTimeout {
				get {
					return TimeSpan.Zero;
				}
			}
			protected override TimeSpan DefaultOpenTimeout {
				get {
					return TimeSpan.Zero;
				}
			}
			public override ServiceProxy GetServiceProxy() {
				var client=new ServiceProxy1();
				// set credentials here
				return client;
			}
			public override void Method() {
			}
		}
		public partial class ServiceProxy2: ServiceProxy1 {
			public override ServiceProxy GetServiceProxy() {
				var client=new ServiceProxy2();
				// set credentials here
				return client;
			}
		}
