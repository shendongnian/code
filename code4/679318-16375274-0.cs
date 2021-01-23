    public Matrix GetRotateToTargetMatrix(Vector3 TargetVector)
    {
                Matrix mBase = Matrix.Invert(Matrix.LookAtLH(new Vector3(0, 0, 0),     TargetVector, new Vector3(0, 1, 0)));
                mBase.M44 = 1;
                mBase.M14 = 0;
                mBase.M24 = 0;
                mBase.M34 = 0;
                mBase.M41 = 0;
                mBase.M42 = 0;
                mBase.M43 = 0;
    
                return = mBase;
    }
