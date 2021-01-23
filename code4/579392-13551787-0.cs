	public static void PremultiplyTexture(Texture2D texture)
	{
		Color[] buffer = new Color[texture.Width * texture.Height];
		texture.GetData(buffer);
		for(int i = 0; i < buffer.Length; i++)
		{
			buffer[i] = Color.FromNonPremultiplied(
					buffer[i].R, buffer[i].G, buffer[i].B, buffer[i].A);
		}
		texture.SetData(buffer);
	}
