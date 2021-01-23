    Stack<Matrix> matrixStack = new Stack<Matrix>();
    ...
    matrixStack.Push( armMatrix );
    ...
    basicEffect.World = matrixStack.Peek();
    foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
    {
        pass.Apply();
        graphics.GraphicsDevice.DrawPrimitives(...);
    }
    basicEffect.End();
    ...
    matrixStack.Pop();
