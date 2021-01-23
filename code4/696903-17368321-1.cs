      // First right aligned paragraph
      p = section.AddParagraph();
      p.Style = Styles.RightAlignedTitle;
      p.AddText("Right aligned text");
      // Second left aligned paragraph
      p = section.AddParagraph();
      p.Format.Alignment = ParagraphAlignment.Left;
      p.AddText("Left aligned text");
