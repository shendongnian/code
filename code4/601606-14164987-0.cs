      public static readonly DependencyProperty NormalImageProperty =
         DependencyProperty.Register(
             NormalImagePropertyTag,
             typeof(ImageSource),
             typeof(CueAnswerViewData),
             new PropertyMetadata(null, (s, e) =>
                    var ctrl = s as CueAnswerViewData;
                    if (ctrl != null) {
                       ctrl.somePropertyToUpdate = 123;
                    }
                })
                );
