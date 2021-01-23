        public interface IDialogService
        {
            void    RegisterDialog  (string dialogID, Type type);
            bool?   ShowDialog      (string dialogID);
        }
        public class DialogService : IDialogService
        {
            private IUnityContainer       m_unityContainer;
            private DialogServiceRegistry m_dialogServiceRegistry;
    
            public DialogService(IUnityContainer unityContainer)
            {
                m_unityContainer = unityContainer;
                m_dialogServiceRegistry = new DialogServiceRegistry();
            }
            public void RegisterDialog(string dialogID, Type type)
            {
                m_dialogServiceRegistry.RegisterDialog(dialogID, type);
            }
    
            public bool? ShowDialog(string dialogID)
            {
                Type type = m_dialogServiceRegistry[dialogID];
                Window window  = m_unityContainer.Resolve(type) as Window;
                bool? dialogResult = window.ShowDialog();
    
                return dialogResult;
            }
        }
