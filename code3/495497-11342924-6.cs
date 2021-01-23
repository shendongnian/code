        void DrawCompass()
        {
           MyTransform.Rotation = 0.0;   // North
           MyTransform.Rotation = 180.0; // South
           MyTransform.Rotation = 90.0;  // East
           MyTransform.Rotation = 270.0; // West
           // Or any other angle in between
           // or simply bind the Rotation property to an angle property on your viewmodel
        }
