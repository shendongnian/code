    protected sealed override Size MeasureCore(Size availableSize)
    {
    	bool useLayoutRounding = this.UseLayoutRounding;
    	if (useLayoutRounding && !base.CheckFlagsAnd(VisualFlags.UseLayoutRounding))
    	{
    		base.SetFlags(true, VisualFlags.UseLayoutRounding);
    	}
    	this.ApplyTemplate();
    	if (this.BypassLayoutPolicies)
    	{
    		return this.MeasureOverride(availableSize);
    	}
    	Thickness margin = this.Margin;
    	double num = margin.Left + margin.Right;
    	double num2 = margin.Top + margin.Bottom;
    	if (useLayoutRounding && this is ScrollContentPresenter)
    	{
    		num = UIElement.RoundLayoutValue(num, FrameworkElement.DpiScaleX);
    		num2 = UIElement.RoundLayoutValue(num2, FrameworkElement.DpiScaleY);
    	}
    	Size size = new Size(Math.Max(availableSize.Width - num, 0.0), Math.Max(availableSize.Height - num2, 0.0));
    	FrameworkElement.MinMax minMax = new FrameworkElement.MinMax(this);
    	FrameworkElement.LayoutTransformData layoutTransformData = FrameworkElement.LayoutTransformDataField.GetValue(this);
    	Transform layoutTransform = this.LayoutTransform;
    	if (layoutTransform != null && !layoutTransform.IsIdentity)
    	{
    		if (layoutTransformData == null)
    		{
    			layoutTransformData = new FrameworkElement.LayoutTransformData();
    			FrameworkElement.LayoutTransformDataField.SetValue(this, layoutTransformData);
    		}
    		layoutTransformData.CreateTransformSnapshot(layoutTransform);
    		layoutTransformData.UntransformedDS = default(Size);
    		if (useLayoutRounding)
    		{
    			layoutTransformData.TransformedUnroundedDS = default(Size);
    		}
    	}
    	else
    	{
    		if (layoutTransformData != null)
    		{
    			layoutTransformData = null;
    			FrameworkElement.LayoutTransformDataField.ClearValue(this);
    		}
    	}
    	if (layoutTransformData != null)
    	{
    		size = this.FindMaximalAreaLocalSpaceRect(layoutTransformData.Transform, size);
    	}
    	size.Width = Math.Max(minMax.minWidth, Math.Min(size.Width, minMax.maxWidth));
    	size.Height = Math.Max(minMax.minHeight, Math.Min(size.Height, minMax.maxHeight));
    	if (useLayoutRounding)
    	{
    		size = UIElement.RoundLayoutSize(size, FrameworkElement.DpiScaleX, FrameworkElement.DpiScaleY);
    	}
    	Size size2 = this.MeasureOverride(size);
    	size2 = new Size(Math.Max(size2.Width, minMax.minWidth), Math.Max(size2.Height, minMax.minHeight));
    	Size size3 = size2;
    	if (layoutTransformData != null)
    	{
    		layoutTransformData.UntransformedDS = size3;
    		Rect rect = Rect.Transform(new Rect(0.0, 0.0, size3.Width, size3.Height), layoutTransformData.Transform.Value);
    		size3.Width = rect.Width;
    		size3.Height = rect.Height;
    	}
    	bool flag = false;
    	if (size2.Width > minMax.maxWidth)
    	{
    		size2.Width = minMax.maxWidth;
    		flag = true;
    	}
    	if (size2.Height > minMax.maxHeight)
    	{
    		size2.Height = minMax.maxHeight;
    		flag = true;
    	}
    	if (layoutTransformData != null)
    	{
    		Rect rect2 = Rect.Transform(new Rect(0.0, 0.0, size2.Width, size2.Height), layoutTransformData.Transform.Value);
    		size2.Width = rect2.Width;
    		size2.Height = rect2.Height;
    	}
    	double num3 = size2.Width + num;
    	double num4 = size2.Height + num2;
    	if (num3 > availableSize.Width)
    	{
    		num3 = availableSize.Width;
    		flag = true;
    	}
    	if (num4 > availableSize.Height)
    	{
    		num4 = availableSize.Height;
    		flag = true;
    	}
    	if (layoutTransformData != null)
    	{
    		layoutTransformData.TransformedUnroundedDS = new Size(Math.Max(0.0, num3), Math.Max(0.0, num4));
    	}
    	if (useLayoutRounding)
    	{
    		num3 = UIElement.RoundLayoutValue(num3, FrameworkElement.DpiScaleX);
    		num4 = UIElement.RoundLayoutValue(num4, FrameworkElement.DpiScaleY);
    	}
    	SizeBox sizeBox = FrameworkElement.UnclippedDesiredSizeField.GetValue(this);
    	if (flag || num3 < 0.0 || num4 < 0.0)
    	{
    		if (sizeBox == null)
    		{
    			sizeBox = new SizeBox(size3);
    			FrameworkElement.UnclippedDesiredSizeField.SetValue(this, sizeBox);
    		}
    		else
    		{
    			sizeBox.Width = size3.Width;
    			sizeBox.Height = size3.Height;
    		}
    	}
    	else
    	{
    		if (sizeBox != null)
    		{
    			FrameworkElement.UnclippedDesiredSizeField.ClearValue(this);
    		}
    	}
    	return new Size(Math.Max(0.0, num3), Math.Max(0.0, num4));
    }
