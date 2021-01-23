    class ChatController : ControllerBase
        {
            #region Views
    
            ChatAreaView viewChatArea;
            //UserListView viewUserArea;
            //MessageView viewMessageArea;
            //LoginPromptView viewLoginPrompt;
    
            #endregion
    
            #region ViewModels
    
            ChatAreaViewModel viewModelChatArea;
            //UserAreaViewModel viewModelUserArea;
            //MessageAreaViewModel viewModelMessageArea;
            //LoginPromptViewModel viewModelLoginPrompt;
    
            #endregion
            public void CreateViewsAndViewModels()
            {
                //InitializeViewAndViewModel(out viewChatArea, out viewModelChatArea);
                //InitializeViewAndViewModel(out viewMessageArea, out viewModelMessageArea);
                //InitializeViewAndViewModel(out viewUserArea, out viewModelUserArea);
                //InitializeViewAndViewModel(out viewLoginPrompt, out viewModelLoginPrompt);
                var a  = new FrameworkElement[] { viewChatArea };
                var b = new object[] { viewModelChatArea};
                InitializeViewsAndViewModels(a,
                                             b);
            }
        }
    
    public abstract class ControllerBase 
        {
            public void InitializeViewAndViewModel<TView, TViewModel>(ref TView view, ref TViewModel viewModel)
                where TView : FrameworkElement, new()
                where TViewModel : new()
            {
                view = new TView();
                viewModel = new TViewModel();
    
                view.DataContext = viewModel;
            }
    
            public void InitializeViewsAndViewModels(FrameworkElement[] views, object[] viewModels)
            {
                if (views.Length != viewModels.Length)
                    throw new ArgumentOutOfRangeException("views and viewModels must have the same number of elements.");
    
                for (int i = 0; i < views.Length; i++)
                    InitializeViewAndViewModel(ref views[i], ref viewModels[i]);
            }
        }
