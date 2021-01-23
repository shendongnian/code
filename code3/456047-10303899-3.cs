    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace FetchTest
    {
        public class DetailEnt
        {
            private Int32? id;
            /// <summary>
            /// Entity key
            /// </summary>
            public virtual Int32? Id
            {
                get { return id; }
                set { id = value; }
            }
    
            private String description;
            /// <summary>
            /// Description
            /// </summary>
            public virtual String Description
            {
                get { return description; }
                set { description = value; }
            }
    
            private MasterEnt rIMaster;
    
            /// <summary>
            /// Gets or sets the RI master.
            /// </summary>
            /// <value>
            /// The RI master.
            /// </value>
            public virtual MasterEnt RIMaster
            {
                get { return rIMaster; }
                set { rIMaster = value; }
            }
        }
    }
