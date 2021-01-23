    using System;
    using System.Windows.Forms;
    
    namespace Demo
    {
        public delegate bool DecisionHandler(string question);
        /// <remarks>
        /// Doesn't know a thing about message boxes
        /// </remarks>    
        public class MyViewModel
        {
            public event DecisionHandler OnDecision;
    
            private void SomeMethod()
            {
                // something...
    
                // I don't know who or what replies! I don't care, as long as I'm getting the decision!
                // Have you made your decision for Christ?!! And action. ;)
                var decision = OnDecision("Do you really want to?"); 
    
                if (decision)
                {
                    // action
                }
                else
                {
                    // another action
                }
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                // this ViewModel will be getting user decision from an actual message box
                var vm = new MyViewModel();
                vm.OnDecision += DecideByMessageBox;
    
                // unlike that one, which we can easily use for testing purposes
                var vmForTest = new MyViewModel();
                vmForTest.OnDecision += SayYes;    
            }        
            /// <summary>
            /// This event handler shows a message box
            /// </summary>        
            static bool DecideByMessageBox(string question)
            {
                return MessageBox.Show(question, String.Empty, MessageBoxButtons.YesNo) == DialogResult.Yes;
            }
            /// <summary>
            /// Simulated positive reply
            /// </summary>        
            static bool SayYes(string question)
            {
                return true;
            }
        }
    }
