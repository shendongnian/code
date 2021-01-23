            private static string GetCallingMethodName()
            {
                const int iCallDeepness = 2; //DEEPNESS VALUE, MAY CHANGE IT BASED ON YOUR NEEDS
                System.Diagnostics.StackTrace stack = new System.Diagnostics.StackTrace(false);
                System.Diagnostics.StackFrame sframe = stack.GetFrame(iCallDeepness);
                return sframe.GetMethod().Name;
            }
