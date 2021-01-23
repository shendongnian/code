    public class PrincipalCommunicator
        {
            public readonly static Lazy<PrincipalCommunicator> _instance = new Lazy<PrincipalCommunicator>(
                    () => new PrincipalCommunicator(GlobalHost.ConnectionManager.GetHubContext<PrincipalHub>())
                );
    
            public List<string> ConnectedUsers { get; set; }
    
            private IHubContext _context;
    
            private PrincipalCommunicator(IHubContext context)
            {
                ConnectedUsers = new List<string>();
                _context = context;
            }
    
            public static PrincipalCommunicatorInstance
            {
                get
                {
                    return _instance.Value;
                }
            }
    
            public bool IsUserConnected(string user)
            {
                return UsuariosConectados.Contains(user);
            }
        }
    
        public class PrincipalHub : Hub
        {
            public override Task OnConnected()
            {
                PrincipalComunicador.Instance.UsuariosConectados.Add(Context.User.Identity.Name);
    			
                return base.OnConnected();
            }
    
            public override Task OnDisconnected(bool stopCalled)
            {
                PrincipalComunicador.Instance.UsuariosConectados.Remove(Context.User.Identity.Name);
                return base.OnDisconnected(stopCalled);
            }
        }
    }
