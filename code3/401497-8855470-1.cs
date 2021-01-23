    using System;
    using System.Threading;
    namespace FlowingText
    {
      class Program
      {
        const int CHARACTER_INTERVAL_IN_MILLISECONDS = 50  ; // interval between characters is 1/4 second (250ms)
        const int PARAGRAPH_INTERVAL_IN_MILLISECONDS = 500 ; // interval between paragraphs is 1 second (1000ms)
        
        static int Main( string[] args )
        {
          foreach ( string paragraph in PARAGRAPHS )
          {
            Display( paragraph ) ;
          }
          return 0 ;
        }
        
        public static void Display( string paragraph )
        {
          EndOfLine() ;
          foreach( char ch in paragraph )
          {
            Thread.Sleep( CHARACTER_INTERVAL_IN_MILLISECONDS ) ;
            DisplayChar( ch ) ;
          }
          EndOfLine() ;
          Thread.Sleep( PARAGRAPH_INTERVAL_IN_MILLISECONDS ) ;
          return ;
        }
        
        private static void DisplayChar( char ch )
        {
          ConsumeInput() ;
          Console.Out.Write( ch ) ;
          Console.Out.Flush() ;
          return ;
        }
        
        private static void EndOfLine()
        {
          ConsumeInput() ;
          Console.Out.WriteLine() ;
          Console.Out.Flush() ;
          return ;
        }
        
        private static void ConsumeInput()
        {
          const bool NO_ECHO = true ;
          
          // consume any pending keystrokes w/o echoing the character
          while( Console.KeyAvailable )
          {
            Console.ReadKey( NO_ECHO ) ;
          }
          
          return ;
        }
        
        private static readonly string[] PARAGRAPHS =
        {
          "Nam non rhoncus sapien. Donec in lorem sed mauris porttitor imperdiet vitae ut nunc. In eu erat non nunc dictum vestibulum. Cras erat dui, fringilla vel pulvinar nec, consequat eu orci. Aliquam erat volutpat. Phasellus rhoncus, lectus a volutpat lacinia, quam turpis venenatis sem, a vestibulum orci nulla congue lacus. Quisque molestie, tellus eu dapibus dictum, erat turpis fringilla nibh, id posuere lacus lectus ut libero." ,
          "Mauris vulputate, nulla porttitor dignissim convallis, ligula odio fermentum leo, et faucibus magna eros nec libero. Nam a risus quis mauris ultricies tempor. Quisque nulla velit, pellentesque at pellentesque ac, dignissim quis metus. Fusce tristique, diam vitae pellentesque tristique, metus risus egestas sapien, at luctus justo arcu a neque. Suspendisse enim augue, laoreet in posuere sit amet, facilisis non tortor. Phasellus quam nisl, ullamcorper non volutpat a, pretium vestibulum metus. Suspendisse at faucibus felis. Ut ullamcorper consectetur velit vitae tincidunt." ,
          "Aenean eget purus a nulla varius volutpat. Duis eget blandit massa. Nunc eget arcu ante, sed congue elit. Phasellus vulputate felis non nibh semper non luctus magna eleifend. Maecenas eget nulla nulla, lobortis tincidunt magna. Proin et lacus est, quis viverra elit. Praesent feugiat dui ut tortor bibendum cursus." ,
          .
          . [elided]
          .
          "Vestibulum enim tellus, suscipit vel vulputate nec, dignissim quis dui. Proin porttitor, orci sed vulputate viverra, nisi sem mollis nisi, ut accumsan quam mauris varius lectus. Vivamus ac nunc ipsum, quis vestibulum nisi. Sed aliquet iaculis leo quis commodo. Sed lorem nisi, tincidunt adipiscing blandit at, porta a metus. Vivamus nec leo eget sapien dapibus consequat vel at lacus. Praesent nec ligula felis, eu malesuada nisi. Vestibulum tincidunt nisl quis nulla suscipit volutpat. Sed at ligula sit amet mauris tincidunt dignissim vel in nibh. Vivamus eget hendrerit erat. Sed fringilla congue lacus vitae convallis. Fusce eget risus sit amet lectus placerat commodo. In ac leo sit amet diam sagittis placerat in ultrices eros. Nam semper, orci et malesuada cursus, mi ipsum gravida dolor, at accumsan est magna sit amet ante. Nulla facilisi." ,
          "Aliquam accumsan dictum luctus. Nunc commodo interdum diam, at feugiat augue semper at. Integer tincidunt, metus quis porta cursus, dolor nisl tincidunt massa, nec rhoncus ipsum ligula sit amet nunc. Fusce velit nunc, bibendum et vestibulum nec, consequat non turpis. Aenean gravida sagittis nulla, ut posuere nulla molestie in. Ut nec odio non arcu pellentesque dapibus. Nullam vel ligula sit amet orci tincidunt congue eu a risus." ,
          "Quisque tempus ipsum ut diam scelerisque egestas. Nam at felis nunc. Proin ut odio lacinia massa sagittis tempus quis et metus. Integer dictum eros vel mi tincidunt eu iaculis augue sollicitudin. Integer vel justo ut mi viverra egestas. Aenean consectetur nisl vel dui interdum quis tincidunt lacus scelerisque. Cras lacus dolor, suscipit eget blandit et, cursus at nunc. In dictum malesuada blandit." ,        
        } ;
        
      }
    }
