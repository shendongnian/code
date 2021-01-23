    ... 
    namespace DenisQuiz.UWP
    {
       public sealed partial class StudyADeck : Page
       {
          ...
          public StudyADeck()
          {
             ...
             // Keyboard shortcuts
             root.KeyDown += Root_KeyDown;
          }
    
          private void Root_KeyDown(object sender, KeyRoutedEventArgs e)
          {
             switch (e.Key)
             {
                case Windows.System.VirtualKey.F:
                   FlipCard();
                   break;
                case Windows.System.VirtualKey.Right:
                   NextCard();
                   break;
                case Windows.System.VirtualKey.Left:
                   PreviousCard();
                   break;
                case Windows.System.VirtualKey.S:
                   Frame.GoBack(); // Stop Studying
                   break;
                case Windows.System.VirtualKey.E:
                   Frame.Navigate(typeof(EditANotecard)); // Edit this card
                   break;
                case Windows.System.VirtualKey.D:
                   DeleteNotecardAsync();
                   break;
                default:
                   break;
             }
          }
    ...
