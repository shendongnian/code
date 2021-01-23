    byte[] bytes = File.ReadAllBytes(fileName);
    Vector3[] data = new Vector3[bytes.Length / 12];
    for (var i = 0; i < data.Length; i++) {
      Vector3 item;
      item.x = BitConverter.ToSingle(bytes, i * 12);
      item.y = BitConverter.ToSingle(bytes, i * 12 + 4);
      item.z = BitConverter.ToSingle(bytes, i * 12 + 8);
      data[i] = item;
    }
