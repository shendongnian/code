        public class BaseClass
        {
		public BaseClass(){}
		public virtual double Eval(double x,double y){return 0;}
	}
	public class MathExpressionParser
	{
		private BaseClass Evalulator=null;
		public MathExpressionParser(){}
		public bool Intialize(string equation)
		{
			Microsoft.CSharp.CSharpCodeProvider cp=new Microsoft.CSharp.CSharpCodeProvider();
			System.CodeDom.Compiler.ICodeCompiler comp=cp.CreateCompiler();
			System.CodeDom.Compiler.CompilerParameters cpar=new CompilerParameters();
 
			cpar.GenerateInMemory=true;
			cpar.GenerateExecutable=false;
			cpar.ReferencedAssemblies.Add("system.dll");
			cpar.ReferencedAssemblies.Add("EquationsParser.exe");	//Did you see this before;
			string sourceCode="using System;"+
							  "class DrivedEval:EquationsParser.BaseClass" +
							  "{"+   
									  "public DrivedEval(){}"+
									  "public override double Eval(double x,double y)"+
									  "{"+
											"return "+ /*Looook here code insertion*/ equation +";"+
									  "}"+
							  "}";
			//the previouse source code will be compiled now(run time);
			CompilerResults result=comp.CompileAssemblyFromSource(cpar,sourceCode);
			//If there are error in the code display it for the programmer who enter the equation
			string errors="";
			foreach(CompilerError rrr in result.Errors)
			{
				if(rrr.IsWarning)
					continue;
				errors+="\n"+rrr.ErrorText;
				errors+="\n"+rrr.ToString();
			}
			//You Can show error if there in the sourceCode you just compiled uncomment the following
			//MessageBox.Show(errors);
			if(result.Errors.Count==0&&result.CompiledAssembly!=null)
			{
				Type objtype=result.CompiledAssembly.GetType("DrivedEval");
				try
				{
					if(objtype!=null)
					{
						Evalulator=(BaseClass)Activator.CreateInstance(objtype);
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message,"Error in Creation the object");
				}
				return true;
			}
			else return false;
		}
		public double evaluate(double x,double y)
		{
			if(Evalulator==null)
				return 0.0;
			return this.Evalulator.Eval(x,y);
		}
	}
