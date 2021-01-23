       public override ProblemCollection Check(Member member)
        {
            Method method = member as Method;
            if (method != null) 
            {
                this.Visit(method.Body);
            }
            return this.Problems;
        }
        public override void VisitMethodCall(MethodCall call)
        {
            base.VisitMethodCall(call);
            Method targetMethod = (Method)((MemberBinding)call.Callee).BoundMember;
            if (targetMethod.Name.Name.Contains("MessageBox.Show"))
               this.Problems.Add(new Problem(this.GetResolution(), call));
        }
