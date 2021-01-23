	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		if (!e.Handled)
		{
			DependencyObject originalSource;
			DependencyObject obj3;
			if (e.Key == Key.Down)
			{
				originalSource = e.OriginalSource as DependencyObject;
				if (originalSource != null)
				{
					UIElement footerPaneHost = this.FooterPaneHost;
					if (((footerPaneHost != null) && footerPaneHost.IsKeyboardFocusWithin) && TreeHelper.IsVisualAncestorOf(footerPaneHost, originalSource))
					{
						obj3 = RibbonHelper.PredictFocus(originalSource, FocusNavigationDirection.Down);
						if (((obj3 == null) || (obj3 == originalSource)) && (this.ItemsPaneMoveFocus(FocusNavigationDirection.First) || this.AuxiliaryPaneMoveFocus(FocusNavigationDirection.First)))
						{
							e.Handled = true;
						}
					}
				}
			}
			else
			{
				UIElement auxiliaryPaneHost;
				if (e.Key == Key.Up)
				{
					UIElement element2 = this._popup.TryGetChild();
					if ((element2 != null) && !element2.IsKeyboardFocusWithin)
					{
						if (this.FooterPaneMoveFocus(FocusNavigationDirection.Last) || this.AuxiliaryPaneMoveFocus(FocusNavigationDirection.Last))
						{
							e.Handled = true;
						}
					}
					else
					{
						originalSource = e.OriginalSource as DependencyObject;
						if (originalSource != null)
						{
							auxiliaryPaneHost = this.AuxiliaryPaneHost;
							if (((auxiliaryPaneHost != null) && auxiliaryPaneHost.IsKeyboardFocusWithin) && TreeHelper.IsVisualAncestorOf(auxiliaryPaneHost, originalSource))
							{
								obj3 = RibbonHelper.PredictFocus(originalSource, FocusNavigationDirection.Up);
								if (((obj3 == null) || (obj3 == originalSource)) && (this.ItemsPaneMoveFocus(FocusNavigationDirection.Last) || this.FooterPaneMoveFocus(FocusNavigationDirection.Last)))
								{
									e.Handled = true;
								}
							}
						}
					}
				}
				else if ((e.Key == Key.Left) || (e.Key == Key.Right))
				{
					originalSource = e.OriginalSource as DependencyObject;
					if (originalSource != null)
					{
						if ((e.Key == Key.Left) == (base.FlowDirection == FlowDirection.LeftToRight))
						{
							auxiliaryPaneHost = this.AuxiliaryPaneHost;
							if (((auxiliaryPaneHost != null) && auxiliaryPaneHost.IsKeyboardFocusWithin) && TreeHelper.IsVisualAncestorOf(auxiliaryPaneHost, originalSource))
							{
								obj3 = RibbonHelper.PredictFocus(originalSource, FocusNavigationDirection.Last);
								if (((obj3 != null) && !TreeHelper.IsVisualAncestorOf(auxiliaryPaneHost, obj3)) && RibbonHelper.Focus(obj3))
								{
									e.Handled = true;
								}
							}
						}
						else if (e.Key == Key.Left)
						{
							ScrollViewer subMenuScrollViewer = base.SubMenuScrollViewer;
							if (((subMenuScrollViewer != null) && subMenuScrollViewer.IsKeyboardFocusWithin) && TreeHelper.IsVisualAncestorOf(subMenuScrollViewer, originalSource))
							{
								RibbonMenuItem item = originalSource as RibbonMenuItem;
								if (item == null)
								{
									item = TreeHelper.FindVisualAncestor<RibbonMenuItem>(originalSource);
								}
								if ((item != null) && !item.CanOpenSubMenu)
								{
									obj3 = item.PredictFocus(FocusNavigationDirection.Right);
									if ((obj3 != null) && RibbonHelper.Focus(obj3))
									{
										e.Handled = true;
									}
								}
							}
						}
					}
				}
			}
			base.OnPreviewKeyDown(e);
		}
	}
	public enum FocusNavigationDirection
	{
		// Résumé :
		//     Déplacer le focus sur l'élément pouvant être actif suivant dans l'ordre de
		//     tabulation.Non pris en charge pour System.Windows.UIElement.PredictFocus(System.Windows.Input.FocusNavigationDirection).
		Next = 0,
		//
		// Résumé :
		//     Déplacer le focus sur l'élément pouvant être actif précédent dans l'ordre
		//     de tabulation.Non pris en charge pour System.Windows.UIElement.PredictFocus(System.Windows.Input.FocusNavigationDirection).
		Previous = 1,
		//
		// Résumé :
		//     Déplacer le focus sur le premier élément pouvant être actif dans l'ordre
		//     de tabulation.Non pris en charge pour System.Windows.UIElement.PredictFocus(System.Windows.Input.FocusNavigationDirection).
		First = 2,
		//
		// Résumé :
		//     Déplacer le focus sur le dernier élément pouvant être actif dans l'ordre
		//     de tabulation.Non pris en charge pour System.Windows.UIElement.PredictFocus(System.Windows.Input.FocusNavigationDirection).
		Last = 3,
		//
		// Résumé :
		//     Déplacer le focus sur un autre élément pouvant être actif et situé à gauche
		//     de l'élément ayant actuellement le focus.
		Left = 4,
		//
		// Résumé :
		//     Déplacer le focus sur un autre élément pouvant être actif et situé à droite
		//     de l'élément ayant actuellement le focus.
		Right = 5,
		//
		// Résumé :
		//     Déplacer le focus sur un autre élément pouvant être actif et situé plus haut
		//     par rapport à l'élément ayant actuellement le focus.
		Up = 6,
		//
		// Résumé :
		//     Déplacer le focus sur un autre élément pouvant être actif et situé plus bas
		//     par rapport à l'élément ayant actuellement le focus.
		Down = 7,
	}
