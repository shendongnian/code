    class ArcSolver
	{
		public Vector3D Center { get; private set; }
		
		public double Radius { get; private set; }
		
		public double Angle { get; private set; }
		
		Vector3D FDirP1, FDirP2;
		//get arc position at t [0..1]
		public Vector3D Arc(double t)
		{
			var x = t*Angle;
			return Center + Radius * Math.Cos(x) * FDirP1 + Radius * Math.Sin(x) * FDirP2;
		}
		
		//Set the points, the arc will go from P1 to P3 though P2.
		public bool SolveArc(Vector3D P1, Vector3D P2, Vector3D P3)
		{
			//to read this code you need to know that the Vector3D struct has
			//many overloaded operators: 
			//~ normalize
			//| dot product
			//& cross product, left handed
			//! length
			
			Vector3D O = (P2 + P3) / 2;
			Vector3D C = (P1 + P3) / 2;
			Vector3D X = (P2 - P1) / -2;
			
			Vector3D N = (P3 - P1).CrossRH(P2 - P1);
			Vector3D D = ~N.CrossRH(P2 - O);
			Vector3D V = ~(P1 - C);
			
			double check = D|V;
			Angle = Math.PI;
			var exist = false;
			
			if (check != 0)
			{
				double t = (X|V) / check;
				Center = O + D*t;
				Radius = !(Center - P1);
				Vector3D V1 = ~(P1 - Center);
                //vector from center to P1
				FDirP1 = V1;
				Vector3D V2 = ~(P3 - Center);
				Angle = Math.Acos(V1|V2);
				
				if (Angle != 0)
				{
					exist = true;
					V1 = P2-P1;
					V2 = P2-P3;
					if ((V1|V2) > 0)
					{
						Angle = Math.PI * 2 - Angle;
					}
				}
			}
			
            //vector from center to P2
			FDirP2 = ~(-N.CrossRH(P1 - Center));
			return exist;
		}
	}
