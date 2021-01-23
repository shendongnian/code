    batch.Begin(SpriteSortMode.FrontToBack, BlendState.Additive);
    batch.Draw(tex1, sprite1, null, Color.White, 0.0f, Vector2.Zero, 1.0f,
    SpriteEffects.None, layer1);
    batch.Draw(tex2, sprite2, null, Color.White, 0.0f, Vector2.Zero, 1.0f,
    SpriteEffects.None, layer2);
    batch.End();
    //new blend state, new begin...end
    batch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
    batch.Draw(tex3, sprite3, null, Color.White, 0.0f, Vector2.Zero, 1.0f,
    SpriteEffects.None, layer3);
    batch.Draw(tex4, sprite4, null, Color.White, 0.0f, Vector2.Zero, 1.0f,
    SpriteEffects.None, layer4);
    batch.End();
