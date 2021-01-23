    namespace SpriteEditor
    {
    #if WINDOWS
        static class Program
        {
            [STAThread]
            static void Main(string[] args)
            {               
                Application.EnableVisualStyles( );
                Application.SetCompatibleTextRenderingDefault( false );
                XnaControlGame.CreateAndShow<SkeletonManagerDialog, SkeletonXnaGame>( );           
            }
        }
    #endif
