    public class A
    {
        private List<B> bList;
        private List<Thread> threadBList;
        private bool aIsReady;
        /// <summary>
        /// List of classes managed by A Class.
        /// </summary>
        public List<B> BList
        {
            get
            {
                return bList;
            }
            set
            {
                bList = value;
            }
        }
        /// <summary>
        /// List of Threads. Each Thread manages a B Class.
        /// </summary>
        public List<Thread> ThreadBList
        {
            get
            {
                return threadBList;
            }
            set
            {
                threadBList = value;
            }
        }
        /// <summary>
        /// Indicates when A is ready.
        /// </summary>
        public bool AIsReady
        {
            get
            {
                return aIsReady;
            }
            set
            {
                aIsReady = value;
            }
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        public A()
        { 
        
        }
        /// <summary>
        /// Starts the A Class.
        /// </summary>
        public void startA()
        {
            this.bList = new List<B>();
            this.threadBList = new List<Thread>();
            // for example
            int numberOfBClasses = 3;
            for (int i = 0; i < numberOfBClasses; ++i)
            {
                B bObject = new B();
                this.bList.Add(bObject);
                Thread bThread = new Thread(bObject.startB);
                bThread.IsBackground = true;
                this.threadBList.Add(bThread);
            }   // for (int i = 0; i < numberOfBClasses; ++i)
            // Start all the B Threads.
            for (int i = 0; i < numberOfBClasses; ++i)
            {
                this.threadBList[i].Start();
            }   // for (int i = 0; i < numberOfBClasses; ++i)
            while (!aIsReady)
            {
                foreach (B bObject in this.bList)
                {
                    if (bObject.BIsReady)
                    {
                        this.aIsReady = true;
                    }   // if (bObject.BIsReady)
                    else
                    {
                        this.aIsReady = false;
                    }   // else [ if (bObject.BIsReady) ]
                }   // foreach (B bObject in this.bList)
            }   // while (!aIsReady)
            this.aIsReady = true;
            
        }
    }   // public class A
    public class B
    {
        private List<C> cList;
        private List<Thread> threadCList;
        private bool bIsReady;
        /// <summary>
        /// List of classes managed by B Class.
        /// </summary>
        public List<C> CList
        {
            get
            {
                return cList;
            }
            set
            {
                cList = value;
            }
        }
        /// <summary>
        /// List of Threads. Each Thread manages a C Class.
        /// </summary>
        public List<Thread> ThreadCList
        {
            get
            {
                return threadCList;
            }
            set
            {
                threadCList = value;
            }
        }
        /// <summary>
        /// Indicates when B is ready.
        /// </summary>
        public bool BIsReady
        {
            get
            {
                return bIsReady;
            }
            set
            {
                bIsReady = value;
            }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public B()
        { 
        
        }
        /// <summary>
        /// Start B
        /// </summary>
        public void startB()
        {
            this.cList = new List<C>();
            this.threadCList = new List<Thread>();
            // for example
            int numberOfCClasses = 5;
            for (int i = 0; i < numberOfCClasses; ++i)
            {
                C cObject = new C();
                this.cList.Add(cObject);
                Thread cThread = new Thread(cObject.startC);
                cThread.IsBackground = true;
                this.threadCList.Add(cThread);
            }   // for (int i = 0; i < numberOfCClasses; ++i)
            // Start all the C Threads.
            for (int i = 0; i < numberOfCClasses; ++i)
            {
                this.threadCList[i].Start();
            }   // for (int i = 0; i < numberOfCClasses; ++i)
            while (!bIsReady)
            {
                foreach (C cObject in this.cList)
                {
                    if (cObject.CIsReady)
                    {
                        this.bIsReady = true;
                    }   // if (cObject.CIsReady)
                    else
                    {
                        this.bIsReady = false;
                    }   // else [ if (cObject.CIsReady) ]
                }   // foreach (C in this.cList)
            }   // while (!bIsReady)
            this.bIsReady = true;
        }
    }   // public class B
    public class C
    {
        private bool cIsReady;
        /// <summary>
        /// Indicates that the object is ready.
        /// </summary>
        public bool CIsReady
        {
            get
            {
                return cIsReady;
            }
            set
            {
                cIsReady = value;
            }
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        public C()
        { 
        
        }
        /// <summary>
        /// Starts C.
        /// </summary>
        public void startC()
        {
            this.cIsReady = true;          
        }
    }   // public class C
