    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using AForge;
    namespace stack_question
    {
        public class Class1
        {
            public AForge.Point center;
            public float radius;
            public List<IntPoint> corners;
            public Class1()
            {
                center = new AForge.Point(3.3F, 4.4F);
                radius = 5.5F;
                corners = new List<IntPoint>();
                corners.Add(new IntPoint(6, 7));
                corners.Add(new IntPoint(8, 9));
            }
        }
    }
