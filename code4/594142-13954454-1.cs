    public class PuzzlePiece
    {
      public int Index { get; set; }
      public Image Piece { get; set; }
    }
    for(int i = 0; i < puzzlePieces.Count; i++)
    {
      if(puzzlePieces[i].Index != playerPieces[i].Index) return false;
    }
    return true;
